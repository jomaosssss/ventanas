function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);

    fetch("/Home/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            $("#tbData tbody").empty();
            data.forEach(item => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.numactfijo),
                        $("<td>").text(item.clavedivision),
                        $("<td>").text(item.clavezona),
                        $("<td>").text(item.claveagencia),
                        $("<td>").text(item.clavetipomtto),
                        $("<td>").text(item.fechaprogramada)
                    )
                );
            });
        });
}

function enviarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);

    fetch("/Home/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            alert(data.mensaje);
        });
}
