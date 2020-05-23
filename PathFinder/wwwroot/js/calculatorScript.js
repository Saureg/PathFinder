function setPointBuy(radio) {
    document.getElementById("point_buy_input").value = radio.value;
    document.getElementById("remaining_points").textContent = radio.value;
    
    let pointInputs = document.getElementsByName("point_input");
    for (let i = 0; i < pointInputs.length; i++)
    {
        pointInputs.item(i).value = "10";
        editCharacteristic(pointInputs.item(i));
    }
}

function editCharacteristic(point) {
    const pointBuyDictionary =
        {
            7: -4,
            8: -2,  
            9: -1,
            10: 0,
            11: 1,
            12: 2,
            13: 3,
            14: 5,
            15: 7,
            16: 10,
            17: 13,
            18: 17
        };
    
    let modValue = -4;
    const modDictionary = {};
    for (let i = 2; i < 43; i+=2){
        modDictionary[i] = modValue;
        modDictionary[i+1] = modValue;
        modValue++;
    }
    
    let parentElement = $(point).parents("tr").get(0);
    let pointValue = $(point).val();
    let racialTraitValue = $(parentElement).find(".trait").text();
    let actualPointValue = parseInt(pointValue) + parseInt(racialTraitValue);

    let remainingElement = document.getElementById("remaining_points");
    
    let currentCoast = pointBuyDictionary[pointValue];
    
    $(parentElement).find("#coast").text(currentCoast);
    $(parentElement).find("#mod").text(modDictionary[pointValue]);
    $(parentElement).find(".actual_points").text(actualPointValue);
    $(parentElement).find(".point_input").val(actualPointValue);
    
    $(parentElement).find("#actual_mod").text(modDictionary[actualPointValue]);
    $(parentElement).find(".mod_input").val(modDictionary[actualPointValue]);
    
    let newRemainingValue = calculateRemaining();
    $(remainingElement).text(newRemainingValue);

    validateRemainingValue(newRemainingValue);
}

function calculateRemaining(){
    let totalRemaining = document.getElementById("point_buy_input").value;
    
    let sum = 0;
    $(".coast").each(function(){
        sum = sum + + $(this).text();
    });
    
    return totalRemaining - sum;
}

function validateRemainingValue(newRemainingValue) {
    if (newRemainingValue < 0){
        document.getElementById("create_button").setAttribute("disabled", "disabled");
        document.getElementById("remaining_points_validation_message").removeAttribute("hidden");
    }
    else {
        document.getElementById("create_button").removeAttribute("disabled");
        document.getElementById("remaining_points_validation_message").setAttribute("hidden", "hidden");
    }
}

function changeRaceTraits() {
    let race = getSelectedRace();
    
    if (race.anyTrait !== 0){
        $("[name='radio_trait']").removeAttr("hidden")  
    } else {
        $("[name='radio_trait']").attr("hidden", "true")
    }
    $("#racial_trait_str").text(race.strTrait)
    $("#racial_trait_dex").text(race.dexTrait)
    $("#racial_trait_con").text(race.conTrait)
    $("#racial_trait_int").text(race.intTrait)
    $("#racial_trait_wis").text(race.wisTrait)
    $("#racial_trait_cha").text(race.chaTrait)
}

function getSelectedRace(){
    let raceId = $("#Character_RaceId").val();
    let race;

    for (let i = 0; i < window.races.length; i++){

        if (window.races[i].id.toString() === raceId){
            race = window.races[i];
        }
    }
    return race;
}

$(document).ready(function () {
        $("#Character_RaceId").change(changeRaceTraits);
        
})

$(document).ready(function () {
    $("#Character_RaceId").change(function () {
        let pointInputs = document.getElementsByName("point_input");
        for (let i = 0; i < pointInputs.length; i++)
        {
            editCharacteristic(pointInputs.item(i));
        }
        selectAnyTrait();
    })
})


$(document).ready(getRaces)

function getRaces() {
    $.ajax({
        type: "GET",
        url: "../Race/SuggestList",
        dataType: "json",
        success: function (data) {
            for (let i = 0; i < data.length; i++) {
                let opt = new Option(data[i].name, data[i].id);
                $("#Character_RaceId").append(opt);
                window.races = data;
            }
            changeRaceTraits();
        }
    });
}

$(document).ready(function () {
    $("[name='radio_trait']").change(selectAnyTrait)
})

function selectAnyTrait() {
    let anyTraitValue = getSelectedRace().anyTrait;
    
    if (anyTraitValue !== 0){
        $("[name='radio_trait']:checked").parent().find(".trait").text(anyTraitValue);
        $("[name='radio_trait']:not(:checked)").parent().find(".trait").text("0");

        let pointInputs = document.getElementsByName("point_input");
        for (let i = 0; i < pointInputs.length; i++)
        {
            editCharacteristic(pointInputs.item(i));
        }   
    }
}