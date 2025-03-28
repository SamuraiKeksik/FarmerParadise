$('#play-button1').on('click', function() {
    window.location.href = "/Home/Saper";
});
$('#play-button2').on('click', function () {
    window.location.href = "/Home/Saper";
});
$('#Auctions').on('click', function () {
    window.location.href = "/Home/Auctions";
});
$('#plant-button').on('click', function () {
    $('#plant-modal').removeClass('d-none');
});

$('#expand-fields').on('click', function () {
    $('#plant-modal').addClass('d-none');
});

function closePlantModal() {
    $('#plant-modal').addClass('d-none');
}

function openSeedModal() {
    $('#seed-modal').removeClass('d-none');
}

function closeSeedModal() {
    $('#seed-modal').addClass('d-none');
}

function openRouletteModal() {
    $('#roulette-modal').removeClass('d-none');
}

function closeRouletteModal() {
    $('#roulette-modal').addClass('d-none');
}

// Обновление количества зерна при перемещении ползунка
$('#seed-slider').on('input', function () {
    $('#selected-seed').text($(this).val());
});