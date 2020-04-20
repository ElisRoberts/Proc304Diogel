(function ( $ ) {
    $.fn.hibpValidate = function() {
        var $this = $(this);
        var pwd = $this.val();

        if (pwd) {
            $.ajax({ 
                url: 'https://haveibeenpwned.com/api/v2/pwnedpassword/' + pwd, 
                crossDomain: true, 
                statusCode: {
                    200: function() {
                        $this.trigger('hibp', [{ pwned: true }]);
                    }, 
                    404: function() {
                        $this.trigger('hibp', [{ pwned: false }]);
                    }, 
            }}); 
        }
    };
}( jQuery ));
