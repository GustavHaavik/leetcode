pub fn full_justify() {
    let words: Vec<String> = vec![
        String::from("This"),
        String::from("is"),
        String::from("an"),
        String::from("example"),
        String::from("of"),
        String::from("text"),
        String::from("justification."),
    ];

    let max_width = words.iter().map(|w: &String| w.len()).max().unwrap() as i32;
    let result = justify(words, max_width);
    for line in result {
        println!("{}", line);
    }
}

fn justify(words: Vec<String>, max_width: i32) -> Vec<String> {
    let mut result: Vec<String> = Vec::new();
    let mut line: Vec<String> = Vec::new();
    let mut line_length: i32 = 0;

    for word in words {
        let word_length = word.len() as i32;
        if line_length + word_length + line.len() as i32 > max_width {
            let line_string = justify_line(&line, line_length, max_width);
            result.push(line_string);
            line.clear();
            line_length = 0;
        }
        line.push(word);
        line_length += word_length;
    }
    let line_string = justify_line(&line, line_length, max_width);
    result.push(line_string);
    result
}

fn justify_line(line: &Vec<String>, line_length: i32, max_width: i32) -> String {
    let mut result: String = String::new();
    let mut space_count = max_width - line_length;
    let mut space_per_word = 1;
    let mut extra_space = 0;
    if line.len() > 1 {
        space_per_word = space_count / (line.len() - 1) as i32;
        extra_space = space_count % (line.len() - 1) as i32;
    }
    for word in line {
        result.push_str(&word);
        if space_count > 0 {
            let mut space = String::new();
            for _ in 0..space_per_word {
                space.push(' ');
            }
            if extra_space > 0 {
                space.push(' ');
                extra_space -= 1;
            }
            result.push_str(&space);
            space_count -= space_per_word + 1;
        }
    }
    result
}
