function apagar(id, controller) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = controller + '/Delete?id=' + id;
}

function verImagem() {
    var oFReader = new FileReader();
    oFReader.readAsDataURL(document.getElementById("Imagem").files[0]);
    oFReader.onload = function (oFREvent) {
        document.getElementById("imgPreview").src = oFREvent.target.result;
    };
}