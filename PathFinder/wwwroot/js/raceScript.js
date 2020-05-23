$(document).ready(
    function() {
    $( "#AnyTrait" ).change(disableTraits);
})

$(document).ready(
    function () {
        $('[class~="trait"]').change()
    }
)

$(document).ready(disableTraits)
$(document).ready(disableAnyTrait)

function disableTraits() {
    let anyTraitValue = $("#AnyTrait").val();
    if (anyTraitValue === "0"){
        $('[class~="trait"]').prop("disabled", false)
    }
    else {
        $('[class~="trait"]').prop("disabled", true)
    }
}

function disableAnyTrait() {
    let traits = $('[class~="trait"]');
    let isEmptyVal = true;

    traits.each(function () {
        if ($(this).val() !== "0"){
            isEmptyVal = false;
            return false;
        }
    })

    if (isEmptyVal === true){
        $( "#AnyTrait" ).prop("disabled", false)
    }
    else {
        $( "#AnyTrait" ).prop("disabled", true)
    }
}