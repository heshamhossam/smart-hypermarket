<?php

class Market extends Eloquent {
	//string contains the name of table in the database
	protected $table = "markets";
	
	//array of fields which can be filled
	protected $fillable = array("name", "location_id");
	
	//location
        public function location()
        {
            return $this->hasOne(Location);
        }
        
        //products in this market
	public function products() {
            return $this->belongsToMany("Product");
	}
        
        //categories in this market
        public function categories()
        {
            return $this->belongsToMany("Category");
        }
        
        
        public function findProduct($uniqueKeyValueArray)
        {
            return Product::retrieve($this, $uniqueKeyValueArray);
        }
        
        public function deleteProduct($product)
        {
            return Product::deleteMe($product->id, $this);
        }
        
        public function addProduct($product, $category, $price)
        {
            //search if category exists in the market
            //$categories = $this->categories()->where("id", "=", $category->id);
            
            //if exist
            $productCreated = $category->addProduct($product);
                
            if ($productCreated)
            {
                //save the product in the market
                $productCreated = DB::table('market_product')->insert(
                        array('market_id' => $this->id, 'product_id' => $product->id, "price" => $price)
                    );
            }
            
            return $productCreated;
            
        }
	
	public function editProduct($product, $newKeyValue)
        {
            
            $updated = DB::table('market_product')
                        ->where('product_id', $product->id)
                        ->where('market_id', $this->id)
                        ->update($newKeyValue);
            
            return $updated;
        }
        
        public function getOrders($filter)
        {
            switch($filter)
            {
                case Order::ALL:
                    $orders = $orders->where("market_id", "=", $this->id)->get();
                    return $orders;
                    break;
                
                case Order::DONE:
                    $orders = Order::where("state", "=", Order::DONE);
                    break;
                    
                case Order::PREPARING:
                    $orders = Order::where("state", "=", Order::PREPARING);
                    break;
                
                case Order::READY:
                    $orders = Order::where("state", "=", Order::READY);
                    break;
                
                case Order::WAITING:
                    $orders = Order::where("state", "=", Order::WAITING);
                    break;
                
                default:
                    $orders = null;
                    break;
                
            }
            
            if ($orders && $orders->count())
            {
                $marketOrders = $orders->where("market_id", "=", $this->id)->get();
                
                $length = $marketOrders->count();
                $ordersArray = $marketOrders->toArray();

                $i = 0;
                foreach($marketOrders as $order)
                {
                    $ordersArray[$i] = array_add($ordersArray[$i], "products", $order->getProducts($this));
                    $i++;
                }

                return $ordersArray;
            }
            
            return null;
            
        }
}