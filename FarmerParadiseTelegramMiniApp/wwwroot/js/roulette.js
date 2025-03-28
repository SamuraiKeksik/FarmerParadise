const elm = (str) => document.querySelector(str);
const elms = (str) => document.querySelectorAll(str);
var selectedItem;

fetch("/Api/Roulette/CanPlayRoulette")
    .then(response => {
        if (!response.ok)
            throw new Error(`HTTP error! Status: ${response.status}`);
        else
            return response.json();
    })
    .then(data => {
        if (data["canPlay"] == true) {
            fetchItems();
        }
    });

function fetchItems() {
    fetch("/Api/Roulette/Items")
        .then(response => {
            if (!response.ok)
                throw new Error(`HTTP error! Status: ${response.status}`);
            else
                return response.json();
        })
        .then(data => {
            const items = data['items'];
            const selectedIndex = Math.floor(Math.random() * items.length);
            for (let i = 0; i < 50; i++) {
                const random = Math.floor(Math.random() * items.length)
                const cellColor = (i % 2) ? 'middle' : ''

                document.querySelector('.scopeHidden > ul').innerHTML += `
                        <li class="roulette-item ${cellColor}" id="${items[random]}">
                            <img src="/icons/${items[random]}.png" />
                            <span>${items[random]}</span>
                        </li>
                     `;
                $("#roulette-modal").removeClass('d-none');
            }
            
        });
}

// Создаеться константа move в которой, в пикселях, вычисляем отступ необходимый
// для списка чтобы тот в свою очередь сдвинулся на n-ое кол-во пикселей

// Далее для более простой читабельности я использовал function expresion
// elm и elms которые просто заменяли мне querySelector и querySelectorAll

// В константе index я учел что мы начинаем не с первой ячейки а с середины, а середина
// в свою очередь может быть разной исходя и размера блока, после монипуляций я возвращаю
// в index не отступы, а ячейку которую в будущем смогу изменить или взять с нее значения

// В этом случае я просто поменял ей цвет на красный

function startRoulette() {
    var itemWidth = $(".roulette-item").first().width();
    if (itemWidth == 150) {
        const move = -150 * 30;
        document.getElementById("btn").disabled = true;
        fetch("/Api/Roulette/Spin")
            .then(result => {
                if (!result.ok)
                    throw new Error(`HTTP error! Status: ${response.status}`);
                else
                    return result.json();
            })
            .then(data => {
                selectedItem = data.result;
                console.log(selectedItem);

                elm('.scopeHidden > ul').style.left = move - 40 + 'px';

                const index = -Math.floor((move + (elm('.scopeHidden').offsetWidth / 2) / -150) / 150) + 1;

                elms('.scopeHidden > ul > li')[index].innerHTML =
                    `<img src="/icons/${selectedItem}.png" />
                    <span>${selectedItem}</span>`;
                elms('.scopeHidden > ul > li')[index].style.background = 'red';
            });
    }

    if (itemWidth == 80) {
        const move = -80 * 30;
        document.getElementById("btn").disabled = true;
        fetch("/Api/Roulette/Spin")
            .then(result => {
                if (!result.ok)
                    throw new Error(`HTTP error! Status: ${response.status}`);
                else
                    return result.json();
            })
            .then(data => {
                selectedItem = data.result;

                elm('.scopeHidden > ul').style.left = move - 40 + 'px';

                const index = -Math.floor((move + (elm('.scopeHidden').offsetWidth / 2) / -80) / 80) + 1;

                elms('.scopeHidden > ul > li')[index].innerHTML =
                    `<img src="/icons/${selectedItem}.png" />
                    <span>${selectedItem}</span>`;
                elms('.scopeHidden > ul > li')[index].style.background = 'red';
            });
    }

    setTimeout(function () {
        $("#closeRouletteButton").removeClass("invisible");
    }, 2200);
};