export interface FormModel {
    id: number;
    name: string;
    field_type_id: number;
    field_type_name: string;
    has_response_values: number;
    is_required: boolean;
    is_integer_only: boolean;
    integer_validation_min: number;
    integer_validation_max: number;
    lookup_dataset: number;
    lookup_dataset_name: string;
    datagrid_id: number;
    status: boolean;
    show_in_tabular: boolean;
    tabular_sort_order: number;
    show_in_detail: boolean;
    detail_sort_order: number;
    response_count: number;
    field_tooltip: string;
    field_selected_value: number;
    edited_field_result_id: number;
    dgFieldCalculation: {
      id: number;
      calc_field1: number;
      calc_field1_transformation: string;
      calc_field2: number;
      mid_operator: string;
      calc_field2_transformation: string;
      enable_post_operator: boolean;
      post_operator: string;
      post_operator_val: number;
      field_id: number;
    };
  }
  