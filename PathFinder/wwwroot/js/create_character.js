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
    let racialTraitValue = $(parentElement).find("#racial_trait").val();
    let actualPointValue = pointValue + racialTraitValue;

    let remainingElement = document.getElementById("remaining_points");
    
    let currentCoast = pointBuyDictionary[pointValue];
    
    $(parentElement).find("#coast").text(currentCoast);
    $(parentElement).find("#mod").text(modDictionary[pointValue]);
    $(parentElement).find("#actual_points").text(actualPointValue);
    $(parentElement).find("#actual_mod").text(modDictionary[actualPointValue]);
    
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