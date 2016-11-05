/// <reference path="../scripts/typings/angularjs/angular.d.ts" />
var DeviceInfoModule;
(function (DeviceInfoModule) {
    var DeviceInfoScriptController = (function () {
        //DeviceStatuses: typeof DeviceStatuses = DeviceStatuses;
        function DeviceInfoScriptController($scope, $element) {
            this.$inject = ["$scope", "$element"];
            $scope.buttonText = "Show/hide devices"; // TODO менять текст кнопки при нажатии
            $scope.deviceInfos = [new DeviceInfo(1, "Heater", DeviceStatuses.On),
                new DeviceInfo(2, "AirConditioner", DeviceStatuses.Off),
                new DeviceInfo(3, "Camera", DeviceStatuses.On)];
            this.scope = $scope;
        }
        return DeviceInfoScriptController;
    }());
    DeviceInfoModule.DeviceInfoScriptController = DeviceInfoScriptController;
    var DeviceInfo = (function () {
        function DeviceInfo(aId, aName, aStatus) {
            this.id = aId;
            this.name = aName;
            this.status = aStatus;
        }
        return DeviceInfo;
    }());
    var DeviceStatuses;
    (function (DeviceStatuses) {
        DeviceStatuses[DeviceStatuses["Unknown"] = 0] = "Unknown";
        DeviceStatuses[DeviceStatuses["On"] = 1] = "On";
        DeviceStatuses[DeviceStatuses["Off"] = 2] = "Off";
    })(DeviceStatuses || (DeviceStatuses = {}));
})(DeviceInfoModule || (DeviceInfoModule = {}));
angular.module("DeviceInfoModule", []).controller("DeviceInfoScriptController", DeviceInfoModule.DeviceInfoScriptController);
