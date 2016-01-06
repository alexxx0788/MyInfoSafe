using System;
namespace MyInfoSafe.Model
{
    public class Bank
    {
        public Bank()
        {
            Type = "current";
        }


       public int Id {get;set;}
       public string BankName {get;set;}
       public decimal Summ  {get;set;}
       public DateTime StartDate  {get;set;}
       public DateTime EndDate  {get;set;}
       public int Month  {get;set;}
       public double Persent { get; set; }
       public string Type {get;set;}
       public string Comment  {get;set;}
       public int Status { get; set; }
       public int DaysLeft { get; set; }


       public static decimal Total { get; set; }
       public static decimal MonthlyIncome { get; set; }
    }
}
