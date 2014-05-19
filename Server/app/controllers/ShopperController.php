<?php


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
//        $productIds = Input::has("product_id1")? Input::get("product_ids") : null;
//        $productQuantities = Input::has("product_quantitie1")? Input::get("product_quantities") : null;
        
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
            $products = array();
            $productIdKey = "product_id";
            $productQunaityKey = "product_quantity";
            while (Input::has($productIdKey . $i) && Input::has($productQunaityKey . $i))
            {
                $productId = Input::get($productIdKey . $i);
                $productQuantity = Input::get($productQunaityKey . $i);
                $products[$i] = Product::find($productId);
                $products[$i]->quantity = $productQuantity;
                $i++;
            }
            $order = $shopper->createOrder($market, $products);
            
            return $order;
        }
        
        return "fail";
        
    }
    
    public function getOrder()
    {
        $orderId = Input::has("id") ? Input::get("id") : 0;
        $order = Order::find($orderId);
        
        if ($order)
        {
            $market = Market::find($order->market_id);
            return $order;
        }
        
        return "faail";
        
    }
    
    public function createReview()
    {
        $productId = Input::has("product_id") ? Input::get("product_id") : 0;
        $body = Input::has("body") ? Input::get("body") : NULL;
        $shopperMobile = Input::has("mobile") ? Input::get("mobile") : 0;
        
        //search for the user
        $shoppers = User::where("mobile", "=", $shopperMobile);
        
        $product = Product::find($productId);
        
        if ($product && $shoppers->count())
        {
            $review = new Review();
            $review->body = $body;
            $review->product_id = $product->id;
            $review->user_id = $shoppers->first()->id;
            $review->save();
            
            if ($review)
                return $review;
        }
        
        return "faail";
        
        
        
        
    }

    
    
}
