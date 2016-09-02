//Classes
//Mixins
//Scope and closers

let db = (function () {

    let Savable = Base=>class extends Base {
        save() {
            // this => obekta varhu koito e izvikan save
            // console.log(this.constructor.name);
            let typeName = this.constructor.name;
            if (typeName == "") {
                typeName = "anonymous";
            }

            if (!dataStorage[typeName]) {
                dataStorage[typeName] = [];
            }
            dataStorage[typeName].push();

        }
    };



    return {
        Saveable,
        list
    }


}());

class Person extends Savable {

}

let dataStorage = {
    'Person': [],
    'Shape': []
};
let p = new Person();
p.save();
let personWithId5 = Person.find(5);

