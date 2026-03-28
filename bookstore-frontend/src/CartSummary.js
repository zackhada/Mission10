import { Link } from 'react-router-dom';
import { useCart } from './CartContext';

function CartSummary() {
  const { totalItems, totalPrice } = useCart();

  return (
    <div className="card bg-light">
      <div className="card-body text-center">
        <h5 className="card-title">
          Cart Summary
        </h5>
        {totalItems === 0 ? (
          <p className="text-muted">Your cart is empty</p>
        ) : (
          <>
            <p className="mb-1">
              <strong>{totalItems}</strong> item{totalItems !== 1 ? 's' : ''}
            </p>
            <p className="fs-5 fw-bold text-success mb-2">
              ${totalPrice.toFixed(2)}
            </p>
            <Link to="/cart" className="btn btn-success btn-sm w-100">
              View Cart
            </Link>
          </>
        )}
      </div>
    </div>
  );
}

export default CartSummary;
