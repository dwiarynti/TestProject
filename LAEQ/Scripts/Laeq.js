
Laeq_LaeqCustomer = function ()
{
    this.$LaeqCustomerId = $("#Id"),
    this.$LaeqCustomerName = $("#Name"),
    this.$LaeqCustomerType = $("#Type")
   
}

Laeq_LaeqCustomer.prototype.Initialize = function()
{
    var instance = this;

}

Laeq_LaeqCustomer.prototype.Search = function () {
    var instance = this;
    var Name = instance.$LaeqCustomerName.val();
    $.ajax({
        type: 'GET',
        url: window.location.href + '/_ListCustomer/?name=' + Name,
        success: function (result) {
            document.getElementById("Detail").innerHTML = result;
        }
    })
}

Laeq_LaeqProject = function () {
    this.$LaeqMachineId = $("#MachineId"),
    this.$LaeqMachine = $("#Machine")
}
Laeq_LaeqProject.prototype.Initialize = function()
{
    var instance = this;
    instance.MachineAutoComplete();
}
Laeq_LaeqProject.prototype.MachineAutoComplete = function () {
    var instance = this;
    $("#Machine").autocomplete({
        source: function (req, response) {
            var getProject = $.ajax({
                url: '../Project/ListMachineNotInProjectAndRent/',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: { name: req.term },
                success: function (rst) {
                    response($.map(rst, function (item) {
                        return {
                            value: item.Id,
                            label: item.MachineID
                        }
                        console.log(rst)
                    }))
                }
            })
        },
        focus: function (event, ui) {
            instance.$LaeqMachine.val(ui.item.label);
        }
       ,
        select: function (ev, ui) {
            instance.Bind_Machine(ui);
            return false;
        }
    })
}
Laeq_LaeqProject.prototype.MachineAutoCompleteEdit = function () {
    var instance = this;
    $("#Machine").autocomplete({
        source: function (req, response) {
            var getProject = $.ajax({
                url: '../ListMachineNotInProjectAndRent/',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: { name: req.term },
                success: function (rst) {
                    response($.map(rst, function (item) {
                        return {
                            value: item.Id,
                            label: item.MachineID
                        }
                        console.log(rst)
                    }))
                }
            })
        },
        focus: function (event, ui) {
            instance.$LaeqMachine.val(ui.item.label);
        }
       ,
        select: function (ev, ui) {
            instance.Bind_Machine(ui);
            return false;
        }
    })
}
Laeq_LaeqProject.prototype.Bind_Machine = function (ui) {
    var instance = this;
    $("#Machine").val(ui.item.label);
    $("#MachineId").val(ui.item.value);
}


Laeq_LaeqRent = function () {
    this.$LaeqMachineId = $("#MachineId"),
    this.$LaeqMachine = $("#Machine"),
    this.$LaeqCustomer = $("#CustomerName")
}
Laeq_LaeqRent.prototype.Initialize = function () {
    var instance = this;
    instance.MachineAutoComplete();
    instance.CustomerAutoComplete();
}
Laeq_LaeqRent.prototype.MachineAutoComplete = function () {
    var instance = this;
    $("#Machine").autocomplete({
        source: function (req, response) {
            var getProject = $.ajax({
                url: '../Rent/ListMachineNotInProjectAndRent/',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: { name: req.term },
                success: function (rst) {
                    response($.map(rst, function (item) {
                        return {
                            value: item.Id,
                            label: item.MachineID
                        }
                        console.log(rst)
                    }))
                }
            })
        },
        focus: function (event, ui) {
            instance.$LaeqMachine.val(ui.item.label);
        }
       ,
        select: function (ev, ui) {
            instance.Bind_Machine(ui);
            return false;
        }
    })
}
Laeq_LaeqRent.prototype.MachineAutoCompleteEdit = function () {
    var instance = this;
    $("#Machine").autocomplete({
        source: function (req, response) {
            var getProject = $.ajax({
                url: '../ListMachineNotInProjectAndRent/',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: { name: req.term },
                success: function (rst) {
                    response($.map(rst, function (item) {
                        return {
                            value: item.Id,
                            label: item.MachineID
                        }
                        console.log(rst)
                    }))
                }
            })
        },
        focus: function (event, ui) {
            instance.$LaeqMachine.val(ui.item.label);
        }
       ,
        select: function (ev, ui) {
            instance.Bind_Machine(ui);
            return false;
        }
    })
}
Laeq_LaeqRent.prototype.Bind_Machine = function (ui) {
    var instance = this;
    $("#Machine").val(ui.item.label);
    $("#MachineId").val(ui.item.value);
}
Laeq_LaeqRent.prototype.CustomerAutoComplete = function () {
    var instance = this;
    $("#CustomerName").autocomplete({
        source: function (req, response) {
            var getProject = $.ajax({
                url: '../Rent/ListCustomer/',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: { name: req.term },
                success: function (rst) {
                    response($.map(rst, function (item) {
                        return {
                            value: item.Id,
                            label: item.Name
                        }
                        console.log(rst)
                    }))
                }
            })
        },
        focus: function (event, ui) {
            instance.$LaeqCustomer.val(ui.item.label);
        }
       ,
        select: function (ev, ui) {
            instance.Bind_Customer(ui);
            return false;
        }
    })
}
Laeq_LaeqRent.prototype.CustomerAutoCompleteEdit = function () {
    var instance = this;
    $("#CustomerName").autocomplete({
        source: function (req, response) {
            var getProject = $.ajax({
                url: '../ListCustomer/',
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                data: { name: req.term },
                success: function (rst) {
                    response($.map(rst, function (item) {
                        return {
                            value: item.Id,
                            label: item.Name
                        }
                        console.log(rst)
                    }))
                }
            })
        },
        focus: function (event, ui) {
            instance.$LaeqCustomer.val(ui.item.label);
        }
       ,
        select: function (ev, ui) {
            instance.Bind_Customer(ui);
            return false;
        }
    })
}
Laeq_LaeqRent.prototype.Bind_Customer = function (ui) {
    var instance = this;
    $("#CustomerName").val(ui.item.label);
    $("#CustomerId").val(ui.item.value);
}


Laeq_LaeqReport = function () {
    this.$LaeqDate1 = $("#Date1"),
    this.$LaeqDate2 = $("#Date2"),
    this.$LaeqType = $("#type")
    

}

Laeq_LaeqReport.prototype.Initialize = function () {
    var instance = this;

}

Laeq_LaeqReport.prototype.Search = function () {
    var instance = this;
    var Date1 = instance.$LaeqDate1.val();
    var Date2 = instance.$LaeqDate2.val();
    var Type = instance.$LaeqType.val();
    console.log(Date1)
    console.log(Type)
    $.ajax({
        type: 'GET',
        url: window.location.href + '/GetDataReport/?date1=' + Date1 + '&date2=' + Date2 +'&type=' + Type,
        success: function (result) {
            document.getElementById("Detail").innerHTML = result;
            console.log(result)
        }
    })
}

Laeq_LaeqReport.prototype.GetTotalRent = function () {
    var instance = this;
    var obj_filtered = [];
    $.ajax({
        type: 'GET',
        url: window.location.href + '/Home/TotalRent',
        success: function (result) {
            obj_filtered.push(result)
        }
    })
    console.log(obj_filtered);
    return obj_filtered;
}

