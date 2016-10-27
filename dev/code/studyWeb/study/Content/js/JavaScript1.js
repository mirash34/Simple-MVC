var InformationFunction = {
    init: function () {


        $(".this").on("click", function (event) {

            $(event.target).closest("tr").next().toggle();


            Title = $(event.target).next("input").val;
            Descripton = $(event.target).next("textarea").val;


            /* if ($(".change-row").css("display")=="none") {
                 $(".change-row").css("display", "block");
              
             }
             else {
                 $(".change-row").css("display", "none");
                 
             }*/


            /*if ($(event.target).closest("tr").next.css("display") == "none")
            {
                $(event.target).closest("tr").next.css("display", "block");
            }
            else
                $(event.target).closest("tr").next.css("display", "none");
          */
        })

    },

    remove: function () { $(".remove").on("click", function (event) { $(event.target).closest("tr").remove(); }) },
    edit: function () {

        $(".buttons").on("click", function (event) {

            /*var InfObject = {
                Id:$(event.target).closest(['rowid']),
                Title: $(event.target).closest('[rowid]').after().find(".Title").get(0).value,
                Description: $(event.target).closest('[rowid]').after().find(".Description").get(0).value,
                PublicationDate: $(event.target).closest('[rowid]').after().find(".PublicationDate").get(0).value
            }
            console.log(InfObject);*/
            FindButton = $(event.target);
            FindString = ($(event.target).closest('[rowid]'));
            FindStringPrev = $(event.target).closest('tr').prev();
            //FindStringPrev.find("current-Description").css('color', 'red');
            
            var a = {
                Id: Number(FindString.attr('rowid')),
                
                Title: FindString.find('.Title').get(0).value,
                Description: FindString.find('.Description').get(0).value,
                PublicationDate: FindString.find('.PublicationDate').get(0).value
            };
            var i = FindString.find('.loader');
            FindButton.css('display','none');
            
                i.css('display','block');
            $.ajax({
                url: '/api/information/edit', data: a
            }).always(function (a) { console.log(a); FindButton.css('display','block'); $(event.target).closest('tr').css('display', 'none'); i.css('display','none');});
            console.log(a)
            FindStringPrev.find(".current-Title").text(a.Title);
            FindStringPrev.find(".current-Description").text(a.Description);
            FindStringPrev.find(".current-PublicationDate").text(a.PublicationDate);
            
            
            /* $(event.target).closest("tr").prev().first(td).text = Title;
             $(event.target).closest("tr").prev().first(td).next().text = Description;
             $(event.target).closest("tr").prev().first(td).next().next().text = PublicationDate;*/
        })
    },
    NewObject: function () { $("#new-element").on("click", function (event) 
    {FindString=$(".NewRow")
        FindString.toggle();        

    })
    }
    /* Save: function (b) {
         var a = { Title: $(b).closest('[rowid]').Title, Description: $(b).closest('[rowid]').Description, PublicationDate: $(b).closest('[rowid]').PublicationDate }
         return a;
     },
     Edit: function(b){ 
         var a ={$(b).closest('[rowid]'): Title, $(b).closest('rowid'):Description, $(b).closest('rowid'):PublicationDate }
     return a
     },
     Remove:function(b){} */




}

$("body").ready(InformationFunction.init);
$("body").ready(InformationFunction.remove);

$("body").ready(InformationFunction.edit);
$("body").ready(InformationFunction.NewObject);
$("body").ready(function () {
    $('.main').on('click', function () {
        $('.first, .second, .third').toggle();
        $('.main').css('opacity', '.7');
        $('.first').toggleClass('.circle-animation');

    })
});