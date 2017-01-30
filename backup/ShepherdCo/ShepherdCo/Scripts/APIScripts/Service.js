app.service("APIService", function ($http) {
    this.getBalance = function () {
        return $http.get("api/balance");
    }

    this.getStock = function () {
        return $http.get("api/stock");
    }
});