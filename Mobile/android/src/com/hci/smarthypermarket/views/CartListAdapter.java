package com.hci.smarthypermarket.views;

import java.util.List;

import com.hci.smarthypermarket.R;

import android.app.Activity;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

public class CartListAdapter extends ArrayAdapter<IShowableItem> {
	
	private Activity _actvitiy;
	private List<IShowableItem> _items;
	
	public CartListAdapter(Activity activityContext, List<IShowableItem> items) {
		super(activityContext, R.layout.item_cart, items);
		_actvitiy=activityContext;
		_items = items;
	}

	@Override
	public View getView(int position, View convertView, ViewGroup parent) {
		// Make sure we have a view to work with (may have been given null)
		View itemView = convertView;
		if (itemView == null) {
			itemView =_actvitiy.getLayoutInflater().inflate(R.layout.item_cart, parent, false);
		}
		
		// Find the car to work with.
		IShowableItem currentProduct = _items.get(position);
		
		
		// Name:
		TextView Name = (TextView) itemView.findViewById(R.id.textViewZeft);
		Name.setText("" + currentProduct.getName().substring(0, 10)+"...");
		
		// PRICE:
		TextView condionText = (TextView) itemView.findViewById(R.id.textViewProductPrice);
		//condionText.setText(Double.toString(currentProduct.getTotalPrice()) + "$");
		condionText.setText(String.valueOf(currentProduct.getPrice() + "$"));
		
		// Countity:
		TextView Countity = (TextView) itemView.findViewById(R.id.textViewCountity);
		Countity.setText(""+currentProduct.getQuantity());
		return itemView;
	}				
}

