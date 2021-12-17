// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI
function AppViewModel() {
    this.strings = ko.observableArray([
        ko.observable("qwe"),
        ko.observable("rty")
    ]);

    this.addStrItem=() => {
        this.strings.push(ko.observable(""));
    }

    this.removeStrItem = (itemToRemove)=> {
        this.strings.remove(itemToRemove);
    }
      
}

// Activates knockout.js
ko.applyBindings(new AppViewModel());