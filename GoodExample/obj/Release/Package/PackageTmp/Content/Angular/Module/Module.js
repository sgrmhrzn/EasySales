var app = angular.module("myApp", ['angularUtils.directives.dirPagination'])
.filter('sumOfValue', function () {
    return function (data, key) {
        //debugger;
        if (angular.isUndefined(data) && angular.isUndefined(key))
            return 0;
        var sum = 0;
        //console.log(data);
        //console.log(key);

        angular.forEach(data, function (v, k) {
            sum = sum + parseInt(v[key]);
        });
        return sum;
    }
}).filter('totalSumPriceQty', function () {
    return function (data, key1, key2) {
        if (angular.isUndefined(data) && angular.isUndefined(key1) && angular.isUndefined(key2))
            return 0;

        var sum = 0;
        angular.forEach(data, function (v, k) {
            sum = sum + (parseInt(v[key1]) * parseInt(v[key2]));
        });
        return sum;
    }
})  .filter('dateRange', function () {
    return function (records, fromDate, toDate) {
        var filtered = [];
        //here you will have your desired input
        //var from_date = Date.parse(fromDate);
        //var to_date = Date.parse(toDate);
        //var fdate = '/Date(' + from_date + ')/';
        //var tdate = '/Date(' + to_date + ')/';

        angular.forEach(records, function (obj) {
            var receivedDate = obj.date;
           console.log(receivedDate);
            if (receivedDate >= fromDate && receivedDate <= toDate) {
                filtered.push(obj);
            }
        });
        //console.log(fromDate + '+' + toDate);
        return filtered;
    };
}).filter('pagination', function () {
    return function (input, start) {
        start = +start;
        return input.slice(start);
    };
}).factory('Excel',function($window){
    var uri='data:application/vnd.ms-excel;base64,',
        template='<html xmlns:o="urn:schemas-microsoft-com:office:office" xmlns:x="urn:schemas-microsoft-com:office:excel" xmlns="http://www.w3.org/TR/REC-html40"><head><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>{worksheet}</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head><body><table>{table}</table></body></html>',
        base64=function(s){return $window.btoa(unescape(encodeURIComponent(s)));},
        format=function(s,c){return s.replace(/{(\w+)}/g,function(m,p){return c[p];})};
    return {
        tableToExcel:function(tableId,worksheetName){
            var table=$(tableId),
                ctx={worksheet:worksheetName,table:table.html()},
                href=uri+base64(format(template,ctx));
            return href;
        }
    };
})
    .controller('excelCtrl',function(Excel,$timeout,$scope){
        $scope.exportToExcel=function(tableId){ // ex: '#my-table'
            var exportHref=Excel.tableToExcel(tableId,'WireWorkbenchDataExport');
            $timeout(function(){location.href=exportHref;},100); // trigger download
        }
    });


