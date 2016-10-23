app.controller("creditCntrl", function ($scope, creditService) {
    $scope.divSales = false;
    GetAllRecords();

    //To Get All Records  
    function GetAllRecords() {
        $scope.loading = true;
        var getData = creditService.getAll();

        getData.then(function (emp) {
            $scope.credits = emp.data;
            $scope.loading = false;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.submit = function () {
        $scope.loading = true;

        $scope.curPage = 0;
        $scope.pageSize = 50;
        $scope.numberOfPages = function () {
            return Math.ceil($scope.resultValue.length / $scope.pageSize);
        };

        //calculate balance
        $scope.calculateBlc = function (index) {
            var sum = 0;
            var balance = 0;
            for (var i = 0; i <= index; i++) {
                sum = balance + $scope.resultValue[i].debit_amount - $scope.resultValue[i].credit_amount;
                balance = sum;
            }
            return balance;
        };

        $scope.serial = function (rowIndex) {
            var serial = ($scope.pageSize * $scope.curPage) + rowIndex;
            return serial;
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

    

});