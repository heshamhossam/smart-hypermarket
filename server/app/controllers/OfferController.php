<?php


/**
 * Description of OfferController
 *
 * @author Hesham
 */
class OfferController extends BaseController {
    
    public function create()
    {
        $marketId = Input::has("market_id") ? Input::get("market_id") : 0;
        $productIds = Input::has("product_ids") ? Input::get("product_ids") : null;
        $productQuantities = Input::has("product_quantities") ? Input::get("product_quantities") : null;
        $teaser = Input::has("teaser") ? Input::get("teaser") : null;
        $name = Input::has("name") ? Input::get("name") : null;
        $price = Input::has("price") ? Input::get("price") : null;
        
        $market = Market::find($marketId);
        
        
        if (!$productIds || !$productQuantities)
        {
            $productIdKey = "product_id";
            $productQunaityKey = "product_quantity";

            $productIds = $this->changeInputsToArray($productIdKey);
            $productQuantities = $this->changeInputsToArray($productQunaityKey);
        }
        
        $products = array();
        $i = 0;
        foreach ($productIds as $productId) {
            $product = Product::find($productId);
            if ($product)
            {
                $products[$i] = $product;
                $products[$i]->quantity = $productQuantities[$i];
                $i++;
            }
        }
        
        if ($market && $teaser && $name && $price && (count($products) > 0) )
        {
            
            $offer = new Offer();
            $offer->teaser = $teaser;
            $offer->name = $name;
            $offer->price = $price;
            
            $market->addOffer($offer, $products);
            
            return $offer;
        }
        
        return "fails";
        
    }
    
    public function retrieve()
    {
        $marketId = Input::has("market_id") ? Input::get("market_id") : 0;
        
        $market = Market::find($marketId);
        $offers = array();
        
        if ($market)
        {
            
            $offers = $market->getOffers()->toArray();
            
        }
        
        return Response::json(array("offers" => $offers));
    }
    
    public function edit()
    {
        $offertId = Input::has("offer_id") ? Input::get("offer_id") : 0;
        
        $offer = Offer::find($offertId);
        
        if ($offer)
        {
            $offer->name = Input::has("name") ? Input::get("name") : $offer->name;
            $offer->price = Input::has("price") ? Input::get("price") : $offer->price;
            $offer->teaser = Input::has("teaser") ? Input::get("teaser") : $offer->teaser;
            return $offer;
        }
        else
            return Response::json(array("success" => FALSE));
        
    }
    
    public function delete()
    {
        $offertId = Input::has("offer_id") ? Input::get("offer_id") : 0;
        
        $offer = Offer::find($offertId);
        
        if ($offer)
            $offer->delete();
        else
            return Response::json(array("success" => FALSE));
    }
    
    public function getCreateOfferForm()
    {
        return View::make("createOffer");
    }
}
