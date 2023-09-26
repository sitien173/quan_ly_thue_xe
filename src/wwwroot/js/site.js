$(function(){
    (function (){
        $('.dropdown-toggle').dropdown()

        $('.chosen').chosen();

        $('.alert').alert();
        
        const $well = $('.well.well-sm');
        if($well.text() === ''){
            $well.hide();
        }
        
        $('.print').click(function(){
            PrintElem();
        });
        
        $('table').each(function(){
            if(!$(this).hasClass('table'))
                $(this).addClass('table table-bordered');
        });
        
        processMoney();

        $('#cancel').click(function(){
            location.href = $('input[name=ReturnUrl]').val();
        })

        $('.confirmDelete').click(function(event){
            if(!confirm('Bạn có chắc chắn muốn xóa?')) {
                event.preventDefault();
            }
        })

        $('[data-val-required]').each(function(){
            const $this = $(this);
            const $parent = $this.parent();
            const $label = $parent.find('label');
            $label.addClass('required');
        })

        baguetteBox.run('.baguetteBox', {
            animation: 'fadeIn',
        });
        
        new FroalaEditor('textarea');
    })();

    function processMoney(){
        const $input = $('input.price');
        const $raw = $('.price');
        $raw.each(function(){
            const $this = $(this);
            const text = $this.text();
            const parsed = parseMoney(text);
            if(parsed)
            {
                $this.text(formatMoney(parseMoney(text)));
            }
        });
        
        $input.each(function(){
            const $this = $(this);
            const value = $this.val();
            const parsed = parseMoney(value);
            if(parsed)
            {
                $this.val(formatMoney(parseMoney(value)));   
            }
        });

        $input.change(function(){
            const $this = $(this);
            const value = $this.val();
            const parsed = parseMoney(value);
            if(parsed)
            {
                $this.val(formatMoney(parseMoney(value)));
            }
        });

        $('form').submit(function(){
            const $money = $(this).find('input.price');
            $money.each(function(){
                const $this = $(this);
                const value = $this.val();
                const parsed = parseMoney(value);
                if(parsed)
                {
                    $this.val(parsed);
                }
            });
        });
    }
});
