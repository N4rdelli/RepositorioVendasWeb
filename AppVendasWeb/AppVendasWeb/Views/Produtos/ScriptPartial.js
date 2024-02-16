//<script>
//    // Função para filtrar as categorias na tabela
//    function filtrarCategorias() {
//        var input = document.querySelector('input[name="buscaCategoria"]').value.toUpperCase();
//    var rows = document.querySelectorAll('#tabelaCategorias tbody tr');
//    console.log(input)
//    rows.forEach(function (row) {
//            var categoriaNome = row.querySelector('td:nth-child(1)').textContent.toUpperCase();
//            if (categoriaNome.indexOf(input) > -1) {
//        row.style.display = '';
//            } else {
//        row.style.display = 'none';
//            }
//        });
//    }

//    document.getElementById('button-addon2').addEventListener('click', filtrarCategorias);

//    document.querySelector('input[name="buscaCategoria"]').addEventListener('keyup', function (event) {
//        if (event.keyCode === 13) {
//        filtrarCategorias();
//        }
//    });
//</script>