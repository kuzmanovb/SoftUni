class Vehicle {

    constructor(type, model, parts, fuel) {
        this.type = type;
        this.model = model;
        this.parts = parts = { engine: 0, power: 0, quality: parts.engine * parts.power };
        this.fuel = fuel;
    }

    drive(fuelLoss) {
        this.fuel -= fuelLoss;
    }
}

let parts = { engine: 6, power: 100 };
let vehicle = new Vehicle('a', 'b', parts, 200);
vehicle.drive(100);
console.log(vehicle.fuel);
console.log(vehicle.parts.quality);

