console.log("JavaScript carregado!");

document.addEventListener("DOMContentLoaded", () => {
  const hamburgerIcon = document.getElementById("hamburger-icon");
  const navLinks = document.getElementById("nav-links");

  if (hamburgerIcon && navLinks) {
    hamburgerIcon.addEventListener("click", () => {
      navLinks.classList.toggle("active");
    });
  }
});
