package com.hci.smarthypermarket;

import java.util.List;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class CartListAdapter extends ArrayAdapter<Product> {
	
	private Activity _actvitiy;
	private List<Product> _products;
	
	public CartListAdapter(Activity activityContext, List<Product> products) {
		super(activityContext, R.layout.item_cart, products);
		_actvitiy=activityContext;
		_products = products;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		// Make sure we have a view to work with (may have been given null)
		View itemView = convertView;
		if (itemView == null) {
			itemView =_actvitiy.getLayoutInflater().inflate(R.layout.item_cart, parent, false);
		}
		
		// Find the car to work with.
		Product currentProduct = _products.get(position);
		
		
		// Name:
		TextView Name = (TextView) itemView.findViewById(R.id.textViewZeft);
		Name.setText("" + currentProduct.getName());
		
		// PRICE:
		TextView condionText = (TextView) itemView.findViewById(R.id.textViewProductPrice);
		//condionText.setText(Double.toString(currentProduct.getTotalPrice()) + "$");
		condionText.setText(String.valueOf(currentProduct.getTotalPrice() + "$"));
		
		// Countity:
		TextView Countity = (TextView) itemView.findViewById(R.id.textViewCountity);
		Countity.setText(""+currentProduct.getPurchasedQuantity());
		return itemView;
	}				
}