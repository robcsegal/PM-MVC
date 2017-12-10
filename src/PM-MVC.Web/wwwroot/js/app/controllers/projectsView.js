PMMVCAngularApp.controller('projectsCtrl', function ($scope, $http) {
    $http({
        url: '/Projects/GetAllProjects',
        method: 'GET'
    }).then(function (data) {
        $scope.projects = data.data;
    })
});