app.service("myService", function ($http) {

    this.getCategory = function () {
        return $http.get("api/stockApi/getCategory");
    };

    //get All Eployee
    this.getEmployees = function () {
      
        return $http.get("api/stockApi");
    };

    // get Employee By Id
    this.getProductById = function (ID) {
        var response = $http({
            method: "GET",
            url: "api/stockApi",
            params: {
                id: JSON.stringify(ID)
            }
        });
        return response;
    }

    // Update Employee 
    this.updateEmp = function (stock) {
        var response = $http({
            method: "post",
            url: "api/stockApi/update",
            data: JSON.stringify(stock),
            dataType: "json"
        });
        return response;
    }

    // Add Employee
    this.AddRecord = function (stock) {
       
        var response = $http({
            method: "post",
            url: "api/stockApi/add",
            data: JSON.stringify(stock),
            dataType: "json"
        });
      
        return response;
    }

    //Delete Employee
    this.DeleteRecord = function (stock) {
        var response = $http({
            method: "post",
            url: "api/stockApi/delete/"+ stock.stock_id,
            data: JSON.stringify(stock),
            dataType: "json"
            //params: {
            //    employeeId: JSON.stringify(employeeId)
           // }
        });
        return response;
    }
});