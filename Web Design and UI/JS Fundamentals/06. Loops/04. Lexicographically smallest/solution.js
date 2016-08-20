function domObjectMinMaxProperty(domObject) {

    var minProperty = domObject;
    var maxProperty = domObject;

    for (var key in domObject) {
        if (key < minProperty) {
            minProperty = key;
        }

        if (key > maxProperty) {
            maxProperty = key;
        }

    }
    console.log(minProperty);
    console.log(maxProperty);
}


solve([9]);