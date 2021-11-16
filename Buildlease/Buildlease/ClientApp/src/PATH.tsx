const MainLink = 'https://localhost:44329/';

const PATH = {
  
  ToProduct: (productId: number) => {
    return MainLink + `products/${productId}`;
  },

  ToCategory: (categoryId: number) => {
    if (categoryId === 0)
      return MainLink + `catalog`;
    return MainLink + `catalog/${categoryId}`;
  },
  
}

export default PATH;