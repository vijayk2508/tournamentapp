(function ($) {
    var Validate = function (element, action, objRules) {
        var $this = this;
        $this.element = $(element);
        $this.CurrentAction = action;
        $this.CurrentRules = objRules;
        $this.init();
    }

    Validate.prototype = {
        init: function () {
            var $this = this;
            $this.element.rules($this.CurrentAction, $this.CurrentRules);
        },
    };

    $.fn.tryrules = function (action, objRules) {
        if (this.length <= 0) {
            console.log("Validation::Element Missing::" + this.selector);
        }
        return this.each(function () {
            var $this = $(this),
                data = $this.data('Validate');
            if (!data) {
                $this.data('Validate', (data = new Validate(this, action, objRules)));
            }
            //if (typeof option === 'string') data[option]();
        });
    };
}(jQuery));
