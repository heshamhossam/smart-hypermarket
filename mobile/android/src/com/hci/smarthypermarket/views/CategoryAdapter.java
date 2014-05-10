package com.hci.smarthypermarket.views;

import java.util.HashMap;
import java.util.List;

import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.Product;

import com.hci.smarthypermarket.R;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.ExpandableListAdapter;
import android.widget.TextView;

public class CategoryAdapter extends BaseExpandableListAdapter {
	private Context context;
	private List<Category> categories;
	private HashMap<Category, List<Product>> products;

	public CategoryAdapter(Context context, List<Category> categories, HashMap<Category, List<Product>> products) {
		this.context = context;
		this.categories = categories;
		this.products = products;
	}
	

	@Override
	public Object getChild(int groupPosition, int childPosition) {
		// TODO Auto-generated method stub
		return this.products.get(this.categories.get(groupPosition)).get(childPosition);
	}

	@Override
	public long getChildId(int groupPosition, int childPosition) {
		// TODO Auto-generated method stub
		return childPosition;
	}

	@Override
	public View getChildView(int groupPosition, int childPosition,
			boolean isLastChild, View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub
		
		//String childText = (String) getChild(groupPosition, childPosition);
		Product product = (Product) getChild(groupPosition, childPosition);
		//childText = product.getName();
		
		if(convertView == null){
			LayoutInflater inflatInflater = (LayoutInflater) this.context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflatInflater.inflate(R.layout.item_product, null);
		}
		
		TextView ProductName = (TextView) convertView.findViewById(R.id.textViewProductName);
		ProductName.setText(product.getName());
		return convertView;
	}

	@Override
	public int getChildrenCount(int groupPosition) {
		// TODO Auto-generated method stub
		return this.products.get(this.categories.get(groupPosition)).size();
	}

	@Override
	public Object getGroup(int groupPosition) {
		// TODO Auto-generated method stub
		return this.categories.get(groupPosition);
	}

	@Override
	public int getGroupCount() {
		// TODO Auto-generated method stub
		return this.categories.size();
	}

	@Override
	public long getGroupId(int groupPosition) {
		// TODO Auto-generated method stub
		return groupPosition;
	}

	@Override
	public View getGroupView(int groupPosition, boolean isExpanded,
			View convertView, ViewGroup parent) {
		// TODO Auto-generated method stub

		Category category = categories.get(groupPosition);
		
		if(convertView == null){
			LayoutInflater inflatInflater = (LayoutInflater) this.context
					.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			convertView = inflatInflater.inflate(R.layout.item_category, null);
		}
		
		TextView CategoryName = (TextView) convertView.findViewById(R.id.textViewCategoryName);
		CategoryName.setText(category.getName());
		return convertView;
	}

	@Override
	public boolean hasStableIds() {
		// TODO Auto-generated method stub
		return false;
	}

	@Override
	public boolean isChildSelectable(int groupPosition, int childPosition) {
		// TODO Auto-generated method stub
		return true;
	}

}
