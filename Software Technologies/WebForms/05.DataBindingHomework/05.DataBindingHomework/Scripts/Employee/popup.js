(function () {
    const root = $("#employees-container");

    root.on("click", "tr", function (ev) {

        const target = $(ev.target);

        const tr = target.parent("tr");
        //  console.log(target);

        let index = +tr.children("td").eq(0).text();

        //  index = Number(index);
        var targetUrl = "/api/employees/" + index;

        $.getJSON(targetUrl)

            .done(function (data) {
               
                
                let targetElement = document.getElementById("info")
                
                let imgContainer = document.createElement("div");
                imgContainer.id = "imageContainer";
                var item_image = data.Photo.replace(/^data:image\/(png|jpg);base64,/, "")
                var src = "data:image/jpeg;base64,";
                src += item_image;
                console.log(src);
                var newImage = document.createElement('img');
                newImage.src = src;
                newImage.width = newImage.height = "80"
                imgContainer.innerHTML = newImage.outerHTML;

                if (targetElement) {
                    targetElement.appendChild(newImage);
                    targetElement.innerHTML = `<br/>Phone: ${data.Phone} <br/> Email: ${data.Email} <br/> Address: ${data.Address} <br/> Notes: ${data.Notes}  <br/><br/>`;
                }
                else {
                    const popup = document.createElement("div");

                    const info = document.createElement("div");
                    info.id = "info";
                    info.appendChild(imgContainer);
                    info.innerHTML = `<br/> Phone: ${data.Phone} <br/> Email: ${data.Email} <br/> Address: ${data.Address} <br/> Notes: ${data.Notes}<br/><br/>`;

                    popup.appendChild(info);
                    document.getElementById("employees-container").appendChild(popup);
                }

            });
    });

})();