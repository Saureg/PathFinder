function setNameForHiddenInputs(checkbox){
    let checkedCheckboxCount = $("input[name='alignment_checkbox']:checked").length - 1;

    if ($(checkbox).is(':checked')){

        $(checkbox).parent().children(".alignment_hidden_input")
            .attr("name", "CharClass.ClassAlignments[".concat(checkedCheckboxCount.toString(), "].AlignmentId"));

        $(checkbox).parent().children(".alignment_class_id_hidden_input")
            .attr("name", "CharClass.ClassAlignments[".concat(checkedCheckboxCount.toString(), "].CharClassId"));

    }
    else {
        $(checkbox).parent().children(".alignment_hidden_input")
            .removeAttr("name");

        $(checkbox).parent().children(".alignment_class_id_hidden_input")
            .removeAttr("name");
    }
}

$(document).ready(function () {
    let checkboxList = $("input[name='alignment_checkbox']");
    let counter = 0;
    
    checkboxList.each(function () {
        if ($(this).is(':checked')){

            $(this).parent().children(".alignment_hidden_input")
                .attr("name", "CharClass.ClassAlignments[".concat(counter.toString(), "].AlignmentId"));
            $(this).parent().children(".alignment_class_id_hidden_input")
                .attr("name", "CharClass.ClassAlignments[".concat(counter.toString(), "].CharClassId"));
            counter++;
        }
    })
})

$(document).ready(
    function () {
        $("input[name='alignment_checkbox']").change(function () {
            setNameForHiddenInputs($(this));
        })
    }
)

$(document).ready(
    function () {
        $("#alignment_all").change(function () {
            let checkboxLocator = $("input[name='alignment_checkbox']");
            if ($(this).is(':checked')){
                $(checkboxLocator).prop('checked', true);
            }
            else {
                $(checkboxLocator).prop('checked', false);
            }
            
            let checkboxList = $(checkboxLocator);
            
            checkboxList.each(function () {
                setNameForHiddenInputs($(this))
            })
        })
    }
)

