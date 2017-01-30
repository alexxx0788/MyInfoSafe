//app.controller('modalcontroller', function ($scope, $uibModal) {
app.controller('APIController',function ($scope, $interval, APIService) {
        $scope.user = {};
        $scope.stocks = {};
        loadBalance();
        loadStocks();

    function loadBalance() {
        var servCall = APIService.getBalance();
        servCall.then(function (d) {
            $scope.user.balance = d.data;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.');
        });
    }

    function loadStocks() {
        var servCall = APIService.getStock();
        servCall.then(function (d) {
            $scope.stocks = d.data;
        }, function (error) {
            console.log('Oops! Something went wrong while fetching the data.');
        });
    }
    $interval(loadStocks, 3000);


    

    })

app.controller('modalcontroller', function ($scope, $uibModal) {
    $scope.msg = "Hi Angular buddy";
    $scope.desc = "this is from desc";
    // $scope.animationsEnabled = true;
    //based on size parameter the size of modal chages.
    $scope.openModal = function (size) {
        var ModalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: '/Home/Order',
            controller: 'InstanceController',
            //appendTo:     //appends the modal to a element
            backdrop: false,  //disables modal closing by click on the background
            //size:size,
            //template: 'myModal.html',
            //keyboard:true,     //dialog box is closed by hitting ESC key
            //openedClass:'nameofClass',  //class styles are applyed after dialog opens.
            resolve: {
                items: function () {
                    //we can send data from here to controller using resolve...
                    return $scope.desc;
                }
            }
            //windowClass:'AddtionalClass',   //class that is added to styles the window template
            //windowTemplateUrl:'Modaltemplate.html',    template overrides the modal template
        });
    };
});

/*
app.controller('InstanceController', function ($scope, $uibModalInstance, items) {
    $scope.ok = function () {
        //it close the modal and sends the result to controller
        $scope.data = "welcome";
        $uibModalInstance.close($scope.data);
    };
    $scope.cancel = function () {
        //it dismiss the modal 
        $uibModalInstance.dismiss('cancel');
    };
});*/



