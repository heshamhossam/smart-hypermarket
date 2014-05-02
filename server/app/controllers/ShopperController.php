<?php

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 * Description of ShopperController
 *
 * @author Hesham
 */
class ShopperController extends BaseController {
    
    public function createOrder()
    {
        $shopperMobile = Input::has("mobile")? Input::get("mobile") : null;
        $firstName = Input::has("first_name")? Input::get("first_name") : null;
        $lastName = Input::has("last_name")? Input::get("last_name") : null;
        $marketId = Input::has("market_id")? Input::get("market_id") : null;
        $productIds = Input::has("product_ids")? Input::get("product_ids") : null;
        $productQuantities = Input::has("product_quantities")? Input::get("product_quantities") : null;
        
        //search for the user
        $shoppers = User::where("mobile", "=", $shopperMobile);
        if ($shoppers->count())
            $shopper = $shoppers->first();
        else
        {
            $shopper = new User();
            $shopper->mobile = $shopperMobile;
            $shopper->first_name = $firstName;
            $shopper->last_name = $lastName;
            $shopper->save();
        }
        
        //search for market
        $market = Market::find($marketId);
        
        if ($market && $shopper)
        {
            $i = 0;
            foreach ($productIds as $productId) {
                $products[$i] = Product::find($productId);
                $products[$i]->quantity = $productQuantities[$i];
                $i++;
            }
            
            $order = $shopper->createOrder($market, $products);
            
            return $order;
        }
        
        
        
    }
    
}
