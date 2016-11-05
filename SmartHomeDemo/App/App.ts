/// <reference path="../scripts/typings/angularjs/angular.d.ts" />

namespace DeviceInfoModule
{
    interface IDeviceInfoScope
    {
        buttonText: string;
        deviceInfos: Array<DeviceInfo>;
    }

    export class DeviceInfoScriptController
    {
        public $inject = ["$scope", "$element"];
        scope: IDeviceInfoScope;
        //DeviceStatuses: typeof DeviceStatuses = DeviceStatuses;

        public constructor($scope: IDeviceInfoScope, $element: JQuery)
        {
            $scope.buttonText = "Show/hide devices"; // TODO менять текст кнопки при нажатии
            $scope.deviceInfos = [  new DeviceInfo(1, "Heater", DeviceStatuses.On),
                                    new DeviceInfo(2, "AirConditioner", DeviceStatuses.Off),
                                    new DeviceInfo(3, "Camera", DeviceStatuses.On)];
            this.scope = $scope;
        }
    }

    class DeviceInfo
    {
        id: number;
        name: string;
        status: DeviceStatuses;

        constructor(aId: number, aName: string, aStatus : DeviceStatuses)
        {
            this.id = aId;
            this.name = aName;
            this.status = aStatus;
        }
    }

    enum DeviceStatuses
    {
        Unknown = 0,
        On,
        Off
    }
}

angular.module("DeviceInfoModule", []).controller("DeviceInfoScriptController", DeviceInfoModule.DeviceInfoScriptController);