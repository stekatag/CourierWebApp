// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const yearEl = document.querySelector(".span-year-footer");
const currentYear = new Date().getFullYear();
yearEl.textContent = currentYear;