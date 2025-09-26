const menu = document.getElementById('menuLink');
console.log(menu);
const btnMenu = document.getElementById('btnMenu');
console.log(btnMenu);

btnMenu.addEventListener('click', () => {
    menu.classList.toggle('ativo');

    if (menu.classList.contains('ativo')) {
        btnMenu.setAttribute('aria-label', 'Fechar menu de navegação');
        btnMenu.setAttribute('aria-expanded', 'false');
    } else {
        btnMenu.setAttribute('aria-label', 'Abrir menu de navegação');
        btnMenu.setAttribute('aria-expanded', 'true');
    }

});