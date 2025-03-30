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

//Таймер выроста урожая
var growTimeText = $("#growTimeText");
setInterval(() => {
    var timeMas = growTimeText.text().split(":");
    var newDate = new Date();
    newDate.setHours(timeMas[0]);
    newDate.setMinutes(timeMas[1]);
    newDate.setSeconds(timeMas[2]);

    newDate.setSeconds(newDate.getSeconds() - 1);
    var newHours = newDate.getHours();
    var newMinutes = newDate.getMinutes();
    var newSeconds = newDate.getSeconds();

    if (newHours == 0 && newMinutes == 0 && newSeconds == 0)
        location.reload();

    growTimeText.text(newHours + ":" + newMinutes + ":" + newSeconds);
}, 1000);