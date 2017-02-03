using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace MyInfoSafe.Yandex
{
    class YandexDiskClient
    {
        string token;
        public string error;

        private void myinit(string token, string error)
        {
            this.error = error;
            this.token = token;
        }

        /// <summary>
        /// Создает экзепляр класса
        /// </summary>
        public YandexDiskClient()
        {
            myinit("", "no errors");
        }

        /// <summary>
        /// Создает экзепляр класса
        /// </summary>
        /// <param name="token">токен доступа</param>
        public YandexDiskClient(string token)
        {
            myinit(token, "no errors");
        }

        /// <summary>
        /// Запрос возвращает информацию о папке dir и всех папках и файлах в нем
        /// </summary>
        /// <param name="dir">Папка</param>
        /// <returns>Список файлов и папок в папке dir или null если произошла ошибка</returns>
        public List<DirInfo> PROPPATCH(string dir)
        {
            HttpWebRequest myweb = (HttpWebRequest) WebRequest.Create("https://webdav.yandex.ru/" + dir);
            myweb.Accept = "*/*";
            myweb.Headers.Add("Depth: 1");
            myweb.Headers.Add("Authorization: OAuth " + token);
            myweb.Method = "PROPFIND";

            try
            {
                HttpWebResponse resp = (HttpWebResponse) myweb.GetResponse();
                StreamReader sr = new StreamReader(resp.GetResponseStream());
                string cont = sr.ReadToEnd();
                List<DirInfo> dinfo = new List<DirInfo>();
                int posBeg, posEnd;
                while (true)
                {
                    posBeg = cont.IndexOf("<d:response>");
                    posEnd = cont.IndexOf("</d:response>");
                    if (posBeg < 0) break;
                    dinfo.Add(ParseDirInfo(cont.Substring(posBeg, posEnd - posBeg)));
                    cont = cont.Substring(posEnd + 1);
                }

                return dinfo;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Запрос удаляет папку (или файл) dir
        /// </summary>
        /// <param name="dir">Папка (или файл) которую надо удалить</param>
        /// <returns>true если запрос выполнен успешно</returns>
        public bool DELETE(string dir)
        {
            HttpWebRequest myweb = (HttpWebRequest) WebRequest.Create("https://webdav.yandex.ru/" + dir);
            myweb.Accept = "*/*";
            myweb.Headers.Add("Depth: 1");
            myweb.Headers.Add("Authorization: OAuth " + token);
            myweb.Method = "DELETE";

            try
            {
                HttpWebResponse resp = (HttpWebResponse) myweb.GetResponse();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Запрос создает папку dir на сервере
        /// </summary>
        /// <param name="dir">Название папки</param>
        /// <returns>true если запрос выполнен успешно</returns>
        public bool MKCOL(string dir)
        {
            HttpWebRequest myweb = (HttpWebRequest) WebRequest.Create("https://webdav.yandex.ru/" + dir);
            myweb.Accept = "*/*";
            myweb.Headers.Add("Depth: 1");
            myweb.Headers.Add("Authorization: OAuth " + token);
            myweb.Method = "MKCOL";

            try
            {
                HttpWebResponse resp = (HttpWebResponse) myweb.GetResponse();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Запрос отправляет файл на сервер
        /// </summary>
        /// <param name="dir">Название файла на сервере (путь к файлу)</param>
        /// <param name="myfile">Загружаемый файл</param>
        /// <returns>true если запрос выполнен успешно</returns>
        public bool PUT(string dir, string myfile)
        {
            HttpWebRequest myweb = (HttpWebRequest) WebRequest.Create("https://webdav.yandex.ru/" + dir);
            myweb.Accept = "*/*";
            myweb.Headers.Add("Depth: 1");
            myweb.Headers.Add("Authorization: OAuth " + token);
            myweb.Method = "PUT";
            myweb.ContentType = "application/binary";
            try
            {
                using (Stream myReqStream = myweb.GetRequestStream())
                {
                    using (FileStream myFile = new FileStream(myfile, FileMode.Open, FileAccess.Read))
                    {
                        using (BinaryReader myReader = new BinaryReader(myFile))
                        {
                            byte[] buffer = myReader.ReadBytes(2048);
                            while (buffer.Length > 0)
                            {
                                myReqStream.Write(buffer, 0, buffer.Length);
                                buffer = myReader.ReadBytes(2048);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

            try
            {
                HttpWebResponse resp = (HttpWebResponse) myweb.GetResponse();
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Запрос скачивает файл с сервера
        /// </summary>
        /// <param name="dir">Путь к файлу на сервере</param>
        /// <param name="myfile">Название файла</param>
        /// <returns>true если запрос выполнен успешно</returns>
        public bool GET(string dir, string myfile)
        {
            HttpWebRequest myweb = (HttpWebRequest) WebRequest.Create("https://webdav.yandex.ru/" + dir);
            myweb.Accept = "*/*";
            myweb.Headers.Add("Depth: 0");
            myweb.Headers.Add("Authorization: OAuth " + token);
            myweb.Method = "GET";
            HttpWebResponse resp = (HttpWebResponse) myweb.GetResponse();
            byte[] bytes = ReadToEnd(resp.GetResponseStream());
            File.WriteAllBytes(myfile, bytes);
            return true;
        }


        public static byte[] ReadToEnd(System.IO.Stream stream)
        {
            long originalPosition = 0;

            if (stream.CanSeek)
            {
                originalPosition = stream.Position;
                stream.Position = 0;
            }

            try
            {
                byte[] readBuffer = new byte[4096];

                int totalBytesRead = 0;
                int bytesRead;

                while ((bytesRead = stream.Read(readBuffer, totalBytesRead, readBuffer.Length - totalBytesRead)) > 0)
                {
                    totalBytesRead += bytesRead;

                    if (totalBytesRead == readBuffer.Length)
                    {
                        int nextByte = stream.ReadByte();
                        if (nextByte != -1)
                        {
                            byte[] temp = new byte[readBuffer.Length * 2];
                            Buffer.BlockCopy(readBuffer, 0, temp, 0, readBuffer.Length);
                            Buffer.SetByte(temp, totalBytesRead, (byte) nextByte);
                            readBuffer = temp;
                            totalBytesRead++;
                        }
                    }
                }

                byte[] buffer = readBuffer;
                if (readBuffer.Length != totalBytesRead)
                {
                    buffer = new byte[totalBytesRead];
                    Buffer.BlockCopy(readBuffer, 0, buffer, 0, totalBytesRead);
                }
                return buffer;
            }
            finally
            {
                if (stream.CanSeek)
                {
                    stream.Position = originalPosition;
                }
            }
        }

        private DirInfo ParseDirInfo(string xml)
        {
            DirInfo rez = new DirInfo();
            rez.creationDate = DirInfo.getData(xml, "creationdate");
            rez.displayName = DirInfo.getData(xml, "displayname");
            rez.contentLenght = Convert.ToInt32(DirInfo.getData(xml, "getcontentlength"));
            rez.lastModified = DirInfo.getData(xml, "getlastmodified");
            return rez;
        }
    }

    public class DirInfo
    {
        public DirInfo()
        {
        }

        public string displayName;
        public int contentLenght;
        public string creationDate;
        public string lastModified;

        public static string getData(string xml, string tag)
        {
            int p1, p2;
            p1 = xml.IndexOf("<d:" + tag + ">");
            p2 = xml.IndexOf("</d:" + tag + ">");
            return xml.Substring(p1 + tag.Length + 4, p2 - 4 - (p1 + tag.Length));
        }
    }
}