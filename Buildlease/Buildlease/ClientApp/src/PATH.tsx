const PATH = {

    ToProduct: (productId: number) => {
        return `products/${productId}`;
    },

    ToCategory: (categoryId: number) => {
        if (categoryId === 0)
            return `catalog`;
        return `catalog/${categoryId}`;
    },
    
    ToOrder: (orderId: number) => {
        return `orders/${orderId}`;
    },
    
    ToHistoricProduct: (productOrderId: number) => {
        return `archived-products/${productOrderId}`;
    },

}

export default PATH;
