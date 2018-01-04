PMMVCAngularApp.controller('projectsCtrl', function ($scope, $http) {
    $http({
        url: '/Projects/GetAllProjects',
        method: 'GET'
    }).then(function (data) {
        $scope.projects = data.data;
    });

    $scope.refresh = function () {
        $http({
            url: '/Projects/GetAllProjects',
            method: 'GET'
        }).then(function (data) {
            $scope.projects = data.data;
        });
    };

    $scope.sendForm = function () {
        $http({
            method: 'POST',
            url: '/Projects/Add',
            data: $scope.project
        }).then(function (data) {
            $scope.refresh();
        })
    }
});