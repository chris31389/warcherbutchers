import { Component, Input } from "@angular/core";
import { Basket } from "../../";

@Component({
    selector: "sidebar",
    templateUrl: "./sidebar.component.html",
    styleUrls: [ "./sidebar.component.css" ]
})
export class SidebarComponent {
    @Input()
    basket: Basket;

    
    constructor() {
        
    }
}

/*

(function () {
  'use strict';

  angular.module('waApp').factory('Basket', [
    '$cookies',
    'ProductListApi',
    'ProductApi',
    'ImageApi',
    'DeliveryApi',
    function ($cookies, ProductListApi, ProductApi, ImageApi, DeliveryApi) {
      var basketId = null;
      var basket = {};
      var productOptions = null;

      basket.deliveryPriceApplied = {
        major: 0,
        minor: 0
      };

      basket.list = [];
      basket.subtotal = {
        major: 0,
        minor: 0
      };
      basket.total = {
        major: 0,
        minor: 0
      };

      var addTwoPrices = function (price1, price2) {
        return {
          major: price1.major + price2.major + Math.floor((price1.minor + price2.minor) / 100),
          minor:  (price1.minor + price2.minor) % 100
        };
      };

      var updatePrice = function () {
        basket.subtotal.major = 0;
        basket.subtotal.minor = 0;
        basket.total.major = 0;
        basket.total.minor = 0;

        basket.list.forEach(function (item) {
          item.total.major = 0;
          item.total.minor = 0;

          for (var i = 0; i < item.quantity; i++) {
            item.total = addTwoPrices(item.total, item.price);
          }

          basket.subtotal = addTwoPrices(basket.subtotal, item.total);

          if (basket.subtotal.major < basket.deliveryDetails.limit.major) {
            basket.deliveryPriceApplied.major = basket.deliveryDetails.price.major;
            basket.deliveryPriceApplied.minor = basket.deliveryDetails.price.minor;
          }else{
            basket.deliveryPriceApplied.major = 0;
            basket.deliveryPriceApplied.minor = 0;
          }

          basket.total = addTwoPrices(basket.subtotal, basket.deliveryPriceApplied);
        });
      };

      var updateBasketApi = function () {
        if (basketId) {
          var items = [];
          basket.list.forEach(function (item) {
            items.push({
              productId: item.productId,
              variationId: item.variationId,
              quantity: item.quantity
            });
          });

          var list = ProductListApi.unsecure.get({id: basketId});
          list.items = items;
          list.lastUpdated = Date.now();
          list.$update({id: basketId});
          list.$update({id: basketId});
        }
      };

      var newBasketApi = function () {
        var items = [];
        basket.list.forEach(function (item) {
          items.push({
            productId: item.productId,
            variationId: item.variationId,
            quantity: item.quantity
          });
        });
        ProductListApi.unsecure.save({items: items}, function (data) {
          basketId = data._id;
          $cookies.put('basket-list', basketId);
        });
        update();
      };

      var update = function () {
        updatePrice();
        updateBasketApi();
      };

      var expired = function (date) {
        var then = new Date(date);
        var now = Date.now();
        return (now - then) > 1209600000; // (14 * 60 * 60 * 24 *1000); // 14 Days
      };

      DeliveryApi.get(function (data) {
        basket.deliveryDetails = data;
        updatePrice();
      });

      return {
        items: basket,
        products: productOptions,
        addItem: function (item) {
          var found = false;

          basket.list.forEach(function (itemThatExists) {
            if (item.variationId === itemThatExists.variationId) {
              found = true;
              itemThatExists.quantity++;
            }
          });

          if (!found) {
            item.quantity = 1;
            item.total = {
              major: 0,
              minor: 0
            };
            basket.list.push(item);
          }

          update();
        },
        removeItem: function (basketItem) {
          if (basketItem.quantity > 1) {
            basketItem.quantity--;
            update();
          } else {
            this.removeItems(basketItem);
          }
        },
        removeItems: function (basketItem) {
          var index = basket.list.indexOf(basketItem);
          if (index > -1) {
            basket.list.splice(index, 1);
          }
          update();
        },
        removeAllItems: function () {
          basket.list.length = 0;
          update();
        },
        getProducts: function (callback) {
          return ProductApi.unsecure.query(function (products) {
            productOptions = products;
            products.forEach(function (item) {
              if (item.imageId) {
                item.imageUrl = item.imageId ? ImageApi.baseUrl + "/" + item.imageId : '../media/default/no-photo-300x200.jpg';
              }
            });
            if (!basketId) {
              basketId = $cookies.get('basket-list');
              if (!basketId) {
                newBasketApi();
              } else {
                ProductListApi.unsecure.get({id: basketId}, function (SavedList) {
                  if (!SavedList.items) {
                    newBasketApi();
                  }
                  else {
                    if (expired(SavedList.lastUpdated)) {
                      update();
                    } else {
                      if (SavedList.items.length > 0) {
                        SavedList.items.forEach(function (basketItem) {
                          products.forEach(function (productItem) {
                            if (
                              productItem.variationId === basketItem.variationId &&
                              productItem.productId === basketItem.productId
                            ) {
                              productItem.quantity = basketItem.quantity;
                              productItem.total = {
                                major: 0,
                                minor: 0
                              };
                              basket.list.push(productItem);
                            }
                          });
                        });
                        update();
                      }
                    }
                  }
                });
              }
            }
            if (callback) {
              callback(products);
            }
          });
        }
      };
    }]);
}());

*/