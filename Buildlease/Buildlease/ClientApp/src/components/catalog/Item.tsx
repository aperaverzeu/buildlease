import { ShoppingCartOutlined } from '@material-ui/icons';
import { Button, message } from 'antd';
import { useState } from 'react';
import API from '../../API';
import PATH from '../../PATH';
import ProductView from '../views/ProductView';

interface ItemProps {
  ProductView: ProductView,
}

export default function Item({ProductView}: ItemProps) {

  const [isAdded, setIsAdded] = useState<boolean>(ProductView.AlreadyInCart);

  return (
    <div className='d-flex flex-row flex-nowrap'
      style={{
        minWidth: 400, 
        width: 400, 
        maxWidth: 400, 
        minHeight: 150, 
        border: 'solid',
      }}
    >
      <div
        style={{ 
          width: 130,
          height: '100%',
          backgroundImage: `url(${ProductView.ImagePath || 'https://www.meme-arsenal.com/memes/d076c825ca4c7745b32e6fa9867ff806.jpg'})`,
          backgroundSize: 'contain',
          backgroundRepeat: 'no-repeat',
          backgroundPosition: 'center',
        }} 
      />
      
      <div className='w-100 d-flex flex-column'
        style={{
          margin: 10,
        }}
      >
        <div style={{fontSize: 16, fontWeight: 'bold'}}>{ProductView.Name}</div>
        <div style={{fontSize: 12, fontWeight: 'lighter'}}>{ProductView.AvailableCount}/{ProductView.TotalCount} available</div>
        <div style={{fontSize: 20, fontWeight: 'lighter'}}>{ProductView.Price ? `$${ProductView.Price} per day` : 'Price is unknown'}</div>
        <div className='d-flex flex-row flex-nowrap justify-content-between'>
          {isAdded ? 
            <Button icon={<ShoppingCartOutlined />} disabled>
              Already in cart
            </Button> 
          :
            <Button icon={<ShoppingCartOutlined />}
              onClick={() => {
                message.loading({ content: 'Wait for it...', key: ProductView.Id, duration: 0 });
                Promise
                .resolve(API.SetProductOrderCount(ProductView.Id, 1))
                .then(() => {
                  message.success({ content: 'Succesfully added to cart!', key: ProductView.Id });
                  setIsAdded(true);
                });
              }}
            >
              Add to cart
            </Button>
          }
          <Button 
            type='link'
            href={PATH.ToProduct(ProductView.Id)}
            target='_blank'
          >
            View details
          </Button>
        </div>
      </div>
    </div>
  );
}
