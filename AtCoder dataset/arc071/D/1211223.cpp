#if 1
#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <map>
#include <set>
#include <unordered_map>
#include <unordered_set>
#include <queue>
#include <stack>
#include <array>
#include <deque>
#include <algorithm>
#include <utility>
#include <cstdint>
#include <functional>
#include <iomanip>
#include <numeric>
#include <assert.h>

auto& in = std::cin;
auto& out = std::cout;

template<typename Arithmetic, typename Integral>
std::enable_if_t< std::is_unsigned<Integral>::value, Arithmetic>
ipow(Arithmetic bace, Integral n)
{
	//???????
	auto res = (Arithmetic)(1);
	while (n > 0) {
		if (n & 1) res *= bace;
		bace *= bace;
		n >>= 1;
	}
	return res;
}
constexpr bool is_prime(uint32_t N)
{
	if (N <= 1) {
		return false;
	}
	for (size_t i = 2; i*i <= N; ++i)
	{
		if (N%i == 0) {
			return false;
		}
	}
	return true;
}
template <uint64_t MOD> class mint_base;
//mint_base_base???????
template <uint64_t MOD> constexpr mint_base<MOD> m_pow(mint_base<MOD> x, uint64_t n)noexcept;
//mod???????????????????
template <uint64_t MOD_ = 1000000007>
class mint_base
{
public:
	static constexpr auto MOD = MOD_;
	static_assert(!(MOD <= 2), "MOD cannot be below 2.");
	static_assert(MOD <= (0xFFFFFFFFFFFFFFFF / 2), "MOD is too big");//??????????????
	static_assert(MOD <= 0xFFFFFFFF, "MOD is too big");//??????????????
	constexpr mint_base<MOD> operator+(const mint_base<MOD> &other)const noexcept
	{
		auto v = *this;
		return v += other;
	}
	constexpr mint_base<MOD> operator-(const mint_base<MOD> &other)const noexcept
	{
		auto v = *this;
		return v -= other;
	}
	constexpr mint_base<MOD> operator*(const mint_base<MOD> &other)const noexcept
	{
		auto v = *this;
		return v *= other;
	}
	constexpr auto operator/(const mint_base<MOD> &other)const noexcept
	{
		auto v = *this;
		return v /= other;
	}
	constexpr mint_base<MOD>& operator+=(const mint_base<MOD> &other) noexcept
	{
		a += other.a;
		if (MOD <= a) { a -= MOD; };
		return *this;
	}
	constexpr mint_base<MOD>& operator-=(const mint_base<MOD> &other) noexcept
	{
		if (a >= other.a) {
			a -= other.a;
		}
		else {
			a = (a + MOD) - other.a;
		}
		return *this;
	}
	constexpr mint_base<MOD>& operator*=(const mint_base<MOD> &other) noexcept
	{
#if 1
		a *= other.a;
		a %= MOD;
#else
		//MOD <= (MAXUINT64 / 2)???
		uint64_t b = other.a, v = 0;
		while (b > 0) {
			if (b & 1) {
				v += a;
				if (v >= MOD)v -= MOD;
			}
			a += a;
			if (MOD <= a)a -= MOD;
			b >>= 1;
		}
		a = v;
#endif
		return *this;
	}
	constexpr std::enable_if_t<is_prime(MOD), mint_base<MOD>&>
		operator/=(const mint_base<MOD> &other) noexcept
	{
		return *this *= ipow(other, MOD - 2);
	}
	constexpr mint_base<MOD> operator+()const noexcept { return *this; }
	constexpr mint_base<MOD> operator-()const noexcept
	{
		return{ MOD - a, mod_value_tag{} };
	}
	constexpr mint_base<MOD>& operator++() noexcept
	{
		if (MOD <= ++a) { a = 0; };
		return *this;
	}
	constexpr mint_base<MOD>& operator--() noexcept
	{
		if (a <= 0) { a = MOD; };
		--a;
		return *this;
	}
	constexpr mint_base<MOD> operator++(int) noexcept
	{
		auto tmp = *this;
		++*this;
		return tmp;
	}
	constexpr mint_base<MOD> operator--(int) noexcept
	{
		auto tmp = *this;
		--*this;
		return tmp;
	}
	constexpr mint_base<MOD> operator~()const noexcept
	{
		return ipow(*this, e_phi - 1);
	}
	constexpr mint_base<MOD>& operator=(const mint_base<MOD> &other) noexcept
	{
		a = other.a;
		return *this;
	}
	constexpr explicit operator uint64_t()const noexcept
	{
		return a;
	}
	constexpr explicit operator unsigned()const noexcept
	{
		return (unsigned)a;
	}
	static constexpr uint64_t getmod() noexcept
	{
		return MOD;
	}
	constexpr mint_base(uint64_t a_) noexcept :a(a_ % MOD) {}
	constexpr mint_base()noexcept : a(0) {}
	struct mod_value_tag {};
	constexpr mint_base(uint64_t a_, mod_value_tag) :a(a_) {}
private:
	static constexpr uint64_t get_e_phi()noexcept {
		//????????
		uint64_t temp = MOD;
		uint64_t m_ = MOD;
		for (uint64_t i = 2; i * i <= m_; ++i)
		{
			if (m_ % i == 0)
			{
				temp = temp / i * (i - 1);
				for (; m_ % i == 0; m_ /= i);
			}
		}
		if (m_ == 1)temp = temp / m_ * (m_ - 1);
		return temp;
	}
	static constexpr uint64_t e_phi = get_e_phi();//?????
	uint64_t a;
};
//mint_base???????
template<uint64_t MOD>constexpr mint_base<MOD> m_pow(mint_base<MOD> x, uint64_t n)noexcept
{
	mint_base<MOD> res = 1;
	while (n > 0)
	{
		if (n & 1)res *= x;
		x *= x;
		n >>= 1;
	}
	return res;
}
//mint_base?????
//O(x)?????????fact_set????????
template<uint64_t MOD>constexpr mint_base<MOD> fact(mint_base<MOD> x)noexcept
{
	mint_base<MOD> res(1);
	for (uint64_t i = 1; i <= (uint64_t)x; ++i)
	{
		res *= i;
	}
	return res;
}
//mint_base?????
//0??x????????
//O(x)?????
template<uint64_t MOD>std::vector<mint_base<MOD>> fact_set(mint_base<MOD> x = mint_base<MOD>(-1))
{
	mint_base<MOD> res(1);
	std::vector<mint_base<MOD>> set((uint64_t)(x)+1);
	set[0] = 1;
	for (uint64_t i = 1; i <= (uint64_t)x; ++i)
	{
		res *= i;
		set[i] = res;
	}
	return res;
}
//mint_base??stream????
template<uint64_t MOD> std::ostream& operator<<(std::ostream& os, mint_base<MOD> i)
{
	os << (uint64_t)i;
	return os;
}
//mint_base??stream?????
template<uint64_t MOD> std::istream& operator >> (std::istream& is, mint_base<MOD>& i)
{
	uint64_t tmp;
	is >> tmp;
	i = tmp;
	return is;
}
typedef mint_base<1000000007> mint;
namespace mint_literal {
	constexpr mint operator""_mi(unsigned long long x)noexcept {
		return mint(x);
	}
}
using namespace mint_literal;
//mint_base?????
//0??x????????
//O(N) //O(1)
template<uint64_t X, uint64_t MOD = mint::MOD>
/*constexpr*/ std::array<mint_base<MOD>, X + 1> fact_set_c()
{
	mint_base<MOD> res(1);
	std::array<mint_base<MOD>, X + 1> set;
	set[0] = 1;
	for (uint64_t i = 1; i <= X; ++i)
	{
		res *= i;
		set[i] = res;
	}
	return set;
}

int32_t N;
mint dp[1000001];
mint dp_sum[1000001];
bool dp_use[1000001];
mint func(int n)
{
	if (n <= 0) {
		return 1_mi;
	}
	if (n == 1) {
		return N;
	}
	if (dp_use[n]) {
		return dp[n];
	}

	//mint res=0;
	//for (int32_t i = 0; i < N; ++i)
	//{
	//	res += mint(std::min(i, n)N) + func(n - 1 - i);
	//}

	mint res = func(n-1);
	for (int32_t i = 2; i <= N; ++i)
	{
		res += func(n - 1 - i);
		res += N-1;
	}
	dp_use[n] = true;
	return dp[n] = res;
}
int main()
{
	using std::endl;
	in.sync_with_stdio(false);
	out.sync_with_stdio(false);

	in >> N;

	dp_sum[0]=dp[0] = 1;
	dp[1] = N;
	dp_sum[1] = N + 1;
	for (int32_t n = 2; n <= N; ++n)
	{
		dp[n] = dp[n - 1];
		if (n >= 4) {
			dp[n] += mint(N - 1)*(N - 1);
			dp[n] += dp_sum[n - 3];
			dp[n] += (N - (n - 1));
		}
		else {
			dp[n] += mint(N - 1)*N;
		}
		dp_sum[n] = dp_sum[n - 1] + dp[n];
	}
	out << dp[(N)] << endl;

	return 0;
}
#endif