<?php

use Illuminate\Auth\UserInterface;
use Illuminate\Auth\Reminders\RemindableInterface;

class User extends Eloquent{ // implements UserInterface, RemindableInterface 

	/**
	 * The database table used by the model.
	 *
	 * @var string
	 */
	protected $table = 'users';
        //array of fields which can be filled
	protected $fillable = array("first_name", "last_name", "mobile");

	/**
	 * The attributes excluded from the model's JSON form.
	 *
	 * @var array
	 */
	protected $hidden = array('password');

	/**
	 * Get the unique identifier for the user.
	 *
	 * @return mixed
	 */
	public function getAuthIdentifier()
	{
		return $this->getKey();
	}

	/**
	 * Get the password for the user.
	 *
	 * @return string
	 */
	public function getAuthPassword()
	{
		return $this->password;
	}

	/**
	 * Get the e-mail address where password reminders are sent.
	 *
	 * @return string
	 */
	public function getReminderEmail()
	{
		return $this->email;
	}
        
        
        //create an order
        public function createOrder($market, $products)
        {
            //create order entry
            $order = new Order();
            $order->state = Order::WAITING;
            $order->market_id = $market->id;
            $order->user_id = $this->id;
            $order->confirmation_code = str_random(5);
            $order->save();
            
            //create each product entry in the order
            foreach ($products as $product) {
                //save the product in the order
                $productAttached = DB::table('order_product')->insert(
                        array(
                            'order_id' => $order->id,
                            'product_id' => $product->id,
                            "quantity" => $product->quantity
                        )
                    );
            }
            
            return $order;
            
        }

}