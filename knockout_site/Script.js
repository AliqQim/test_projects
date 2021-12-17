// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function AppViewModel() {
    this.strings = ko.observableArray([
        { str: ko.observable("qwe")},
        { str: ko.observable("rty")}
    ]);

    this.addStrItem=() => {
        this.strings.push({ str: ko.observable("") });
    }

    this.removeStrItem = (itemToRemove)=> {
        this.strings.remove(itemToRemove);
    }
      
}

// Activates knockout.js
ko.applyBindings(new AppViewModel());