pub fn climb_stairs() {
    let n = 5;
    let result = climb(n);
    println!("result: {}", result);
}

fn climb(n: i32) -> i32 {
    if n == 1 {
        return 1;
    }
    let mut dp = vec![0; n as usize + 1];
    dp[1] = 1;
    dp[2] = 2;
    for i in 3..=n as usize {
        dp[i] = dp[i - 1] + dp[i - 2];
    }
    dp[n as usize]
}
