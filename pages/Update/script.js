const uploadFoto = document.getElementById('uploadFoto');
const fotoUsuario = document.getElementById('fotoUsuario');

uploadFoto.addEventListener('change', function () {
  const arquivo = this.files[0];
  if (arquivo) {
    const leitor = new FileReader();
    leitor.onload = function (e) {
      fotoUsuario.src = e.target.result;
    };
    leitor.readAsDataURL(arquivo);
  }
});





