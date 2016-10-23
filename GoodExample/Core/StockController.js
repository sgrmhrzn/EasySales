app.controller("myCntrl", function ($scope, myService, $window) {
    $scope.stocks = [];

    $scope.divAddEdit = false;
    $scope.loading = false;
    GetAllEmployee();


    $scope.curPage = 0;
    $scope.pageSize = 50;
    $scope.numberOfPages = function () {
        return Math.ceil($scope.resultValue.length / $scope.pageSize);
    };

    $scope.serial = function (rowIndex) {
        var serial = ($scope.pageSize * $scope.curPage) + rowIndex;
        return serial;
    };
    $scope.submit = function () {

    }
    //To Get All Records  
    function GetAllEmployee() {
        $scope.loading = true;
        var getData = myService.getEmployees();
      
        getData.then(function (emp) {
            $scope.stocks = emp.data;
            $scope.loading = false;
        },function () {
            alert('Error in getting records');
        });
    }

    $scope.editRecord = function (stock) {
        debugger;
        var getData = myService.getProductById(stock.stock_id);
        console.log(stock.prices.cost_price);
        getData.then(function (stc) {
            $scope.stocks = stc.data;
            $scope.stockId = stock.stock_id;
            $scope.productDes = stock.product_des;
            $scope.barCode = stock.barCode;
            $scope.itemCode = stock.item_code;
            $scope.category = stock.catagory;
            $scope.qty = stock.qty_left;
            $scope.vendor = stock.vendor;
            $scope.cost_price = stock.prices.cost_price;
            $scope.selling_price = stock.prices.selling_price;
            $scope.margin = stock.prices.margin;
            $scope.Action = "Update";
            $scope.divAddEdit = true;
        },
        function () {
            alert('Error in getting records');
        });
    }

    $scope.AddUpdate = function ()
    {
        var stocks = {
            //id: $scope.stock.stock_id,
            product_des: $scope.productDes,
            barCode: $scope.barCode,
            item_code: $scope.itemCode,
            qty_left: $scope.qty,
            catagory: $scope.category,
            vendor: $scope.vendor,
            prices: {
                cost_price: $scope.cost_price,
                selling_price:$scope.selling_price,
                margin:$scope.margin
            }
        };
        var getAction = $scope.Action;

        if (getAction == "Update") {
            stocks.stock_id = $scope.stockId;
            var getData = myService.updateEmp(stocks);
            getData.then(function (msg) {
                GetAllEmployee();
                alert(msg.data);
                $scope.divAddEdit = false;
            }, function () {
                alert('Error in updating record');
            });
        }
        else {
            var getData = myService.AddRecord(stocks);
            getData.then(function (msg) {
                GetAllEmployee();
                alert(msg.data);
                $scope.divAddEdit = false;
            }, function () {
                alert('Error in adding record');
            });
        }
        $scope.divAddEdit = false;
        debugger;
        GetAllEmployee();
    }

    //$scope.apply(function () {
    //    debugger;
    //    // update goes here
    //    GetAllEmployee();
    //});


    $scope.AddUpdateProduct = function ()
    {
        ClearFields();
        $scope.Action = "Add";
        $scope.divAddEdit = true;
    }
    $scope.cancel = function () {
        //If DIV is visible it will be hidden and vice versa.
        $scope.IsVisible = false;
    }
    $scope.deleteProduct = function (stock)
    {
        debugger;
        
        deleteUser = $window.confirm('Are you sure you want to delete the ' + stock.product_des + '?');
        if (deleteUser) {
            var getData = myService.DeleteRecord(stock);
            getData.then(function (msg) {
                GetAllEmployee();
                alert('Product Deleted');
            }, function () {
                alert('Error in Deleting Record');
            });
        }
    }

    function ClearFields() {
        $scope.stocks = '';
        $scope.stockId = '';
        $scope.productDes = '';
        $scope.barCode ='';
        $scope.itemCode = '';
        $scope.category = '';
        $scope.qty = '';
        $scope.vendor = '';
        $scope.cost_price = '';
        $scope.selling_price = '';
        $scope.margin = '';
    }
});