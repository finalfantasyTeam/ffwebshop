'use strict';
var ShoppingCart = (function (jQuery) {
    var $ = jQuery;

    if ($ === undefined) {
        throw new Error('Shopping Cart requires jQuery');
    }

    // Shopping Cart
    $('.add-cart').click(function () {
        var product = JSON.parse($(this).attr('data-product'));
        var productQuantity = Number($('#txtProductQuatity').attr('value')) || 1;
        var currentCart = JSON.parse(localStorage.getItem("GemShopCart")) || [];
        var isInCart = false;

        currentCart.forEach(function (item) {
            if (item.Id === product.Id) {
                item.Quantity += productQuantity;
                isInCart = true;
                return;
            }
        });

        if (!isInCart) {
            var cartItem = {
                Id: product.Id,
                Name: product.Name,
                Price: product.Price,
                FeatureImage: product.FeatureImage,
                Quantity: productQuantity
            };

            currentCart.push(cartItem);
        }

        localStorage.setItem('GemShopCart', JSON.stringify(currentCart));
        UpdateShoppingCartBox(currentCart);
    });

    function initCart() {
        if (localStorage.getItem("GemShopCart")) {
            var currentCart = JSON.parse(localStorage.getItem("GemShopCart")) || [];
            UpdateShoppingCartBox(currentCart);
        }
    }

    function UpdateShoppingCartBox(cart) {
        var boxCart = $("#boxShopingCart");
        boxCart.empty();

        cart.forEach(function (item, index) {
            var boxItem = '<li>' +
                            '<a href="Product/productId=' + item.Id + '" class="product-image"><img class="replace-2x" src="' + item.FeatureImage + '" width="70" height="70" alt=""></a>' +
                            '<a onclick="ShoppingCart.RemoveCartItem(' + item.Id + ')" href="#" class="product-remove">X</a>' +
                            '<h4 class="product-name"><a href="Product/productId=' + item.Id + '" title="">' + item.Name + '</a></h4>' +
                            '<div class="product-price">' + item.Quantity + ' x <span class="price">' + $.formatNumber(item.Price, { format: "₹ #,###.00", locale: "in" }) + '</span></div>' +
                            '<div class="clearfix"></div>' +
                        '</li>';
            boxCart.append(boxItem);
        });
    }

    function removeCartItem(productId) {
        var currentCart = JSON.parse(localStorage.getItem("GemShopCart")) || [];

        currentCart.forEach(function (item, index) {
            if (item.Id === productId) {
                item.Quantity--;
                if (item.Quantity <= 0) {
                    currentCart.splice(index, 1);
                }
            }
        });

        localStorage.setItem('GemShopCart', JSON.stringify(currentCart));
        UpdateShoppingCartBox(currentCart);
    }

    function sendCart() {
        $.ajax({
            url: 'Sales/ReceiveCartBox',
            type: 'post',
            data: localStorage.getItem("GemShopCart"),
            success: function (data) {
                console.log(data);
            }
        });
    }

    return {
        RemoveCartItem: removeCartItem,
        SendCartToServer: sendCart,
        InitCart: initCart
    };

}(this.jQuery));