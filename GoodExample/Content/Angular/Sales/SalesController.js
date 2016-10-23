app.controller("salesCntrl", function ($scope, salesService) {
    $scope.divSales = false;
    GetAllSales();

    

    //To Get All Records  
    function GetAllSales() {

        $scope.loading = true;
        var getData = salesService.getSales();
        
        getData.then(function (emp) {
            $scope.sales = emp.data;
            $scope.loading = false;
        }, function () {
            alert('Error in getting records');
        });
    }

    function ClearFields() {
        $scope.employeeId = "";
        $scope.employeeName = "";
        $scope.employeeEmail = "";
        $scope.employeeAge = "";
    }


    $scope.dateStart = "";
    $scope.dateEnd = "";
    $scope.searchDescription = "";
    $scope.bCode = "";
    $scope.bill = "";

    $scope.submit = function () {
        $scope.loading = true;

        $scope.serial = function (rowIndex) {
            var serial = ($scope.pageSize * $scope.curPage) + rowIndex;
            return serial;
        };

        $scope.curPage = 0;
        $scope.pageSize = 50;
        $scope.numberOfPages = function () {
            return Math.ceil($scope.resultValue.length / $scope.pageSize);
        };

        var start = $scope.FromDate;
        var end = $scope.ToDate;

        var parsed_start_date = Date.parse(start);
        var parsed_end_date = Date.parse(end);

        var start_date = '/Date(' + parsed_start_date + ')/';
        var end_date = '/Date(' + parsed_end_date + ')/';

        $scope.dateStart = start_date;
        $scope.dateEnd = end_date;
        //var date2 = $scope.q;
        //    console.log(date2);

        $scope.loading = false;
    }

    //get total
    $scope.sales = [];
    $scope.getTotal = function () {
        var total = 0;
        console.log($scope.sales.lenght);
        for (var i = 0; i < $scope.sales.lenght; i++) {
            var sales = $scope.sale[i];
            total += sales.total_price ;
        }
        return total;
    }

});