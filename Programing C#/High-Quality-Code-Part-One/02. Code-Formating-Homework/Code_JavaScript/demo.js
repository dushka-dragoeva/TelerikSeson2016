'use strict';

class Hourse {

    constructor(name, furColor, age) {
        this.numerOfLegs = 4;
        this._name = name;
        this._furColor = furColor;
        this._age = age;
    }

    makeSound() {
        console.log(this._name + ': cvili');
    }

    toString(){
        return `${this._name} is a ${this._furColor} and is ${this._age} tears old`;
    }


}




