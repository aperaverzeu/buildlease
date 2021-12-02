const MainLink = 'https://localhost:5001/';

const PATH = {

    ToProduct: (productId: number) => {
        return MainLink + `products/${productId}`;
    },

    ToCategory: (categoryId: number) => {
        if (categoryId === 0)
            return MainLink + `catalog`;
        return MainLink + `catalog/${categoryId}`;
    },
    
    ToOrder: (orderId: number) => {
        return MainLink + `orders/${orderId}`;
    },
    
    ToHistoricProduct: (productOrderId: number) => {
        return MainLink + `archived-products/${productOrderId}`;
    },

}

export default PATH;
